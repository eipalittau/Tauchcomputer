using ETCalc.Calculator;
using ETCalc.Calculator.Bühlmann;
using ETCalc.Calculator.DTO;
using System.Collections.ObjectModel;

namespace ETCalc {
    internal class DiveData {
        private readonly ICalculator Calculator;

        /// <summary>Oberflächendruck in bar.</summary>
        public double SurfacePressure { get; init; }

        /// <summary>Liste der mitgeführten Gase.</summary>
        public List<MixtureDTO> Mixtures { get; init; }

        public DiveProfileResult? Current { get; private set; }

        private readonly List<DiveProfileData> _Profile = [];
        public ReadOnlyCollection<DiveProfileData> Profile => _Profile.AsReadOnly();

        public DiveData(double pSurfacePressure) {
            SurfacePressure = pSurfacePressure;
            Mixtures = [ new MixtureDTO(Enumeration.ModeEnum.Surfacegas,
                                        new MixtureGasDTO(GasEnum.O2, GasEnum.O2.StandardGasFraction),
                                        new MixtureGasDTO(GasEnum.N2, 100 - GasEnum.O2.StandardGasFraction - GasEnum.He.StandardGasFraction),
                                        new MixtureGasDTO(GasEnum.He, GasEnum.He.StandardGasFraction)) ];
            Calculator = new Calculator.Bühlmann.Calculator(this, GasEnum.Enumerate(true).Select(x => new GasData(x)).ToArray());
        }

        public void ProcessNewMeasurement(double pAmbientPressure, double pExposureTime, MixtureDTO pMixture) {
            _Profile.Add(new DiveProfileData(_Profile.Count + 1, DateTime.Now, pAmbientPressure, pExposureTime, pMixture));
            Current = Calculator.Calculate(pAmbientPressure, pExposureTime);

            if (Current.NDL < 0) {
                //ICalculator tmpCalculator = new Calculator.Bühlmann.Calculator(this, (GasData[])Calculator.GasComposition.Clone());
                ICalculator simCalculator = Calculator.Clone();
                double simAmbientPressure = pAmbientPressure;

                while (simAmbientPressure % 0.3 != 0) {
                    simAmbientPressure -= 0.1;
                }
                Current.DecoStops.Clear();

                while (simAmbientPressure > SurfacePressure) {
                    DiveProfileResult simProfile = simCalculator.Calculate(simAmbientPressure, Settings.CalculationInterval);
                    DecoStopDTO? deepestStop = Current.DecoStops.FirstOrDefault(x => x.AmbientPressure == simProfile.NextDecoStop.AmbientPressure);

                    if (deepestStop is null) {
                        Current.DecoStops.Add(simProfile.NextDecoStop);
                    }

                    if (simProfile.NextDecoStop.Time <= 0) {
                        simAmbientPressure -= (Settings.MaximumAscent * Settings.CalculationInterval);
                    }
                }
            }
        }

        /// <summary>Fügt ein weiteres Atemgas der Auflistung hinzu.</summary>
        /// <param name="pGas"></param>
        public void AddMixture(MixtureDTO pGas) {
            if (!Mixtures.Contains(pGas)) {
                Mixtures.Add(pGas);
            }
        }
    }
}