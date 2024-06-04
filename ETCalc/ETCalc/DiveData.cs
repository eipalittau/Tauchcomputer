using ETCalc.Calculator;
using ETCalc.Calculator.Bühlmann;
using System.Collections.ObjectModel;

namespace ETCalc {
    internal class DiveData {
        private ICalculator Calculator;

        /// <summary>Oberflächendruck in bar.</summary>
        public double SurfacePressure { get; init; }

        /// <summary>Liste der mitgeführten Gase.</summary>
        public List<MixtureDTO> Mixtures { get; init; }

        public Calculator.DTO.DiveProfileResult? Current { get; private set; }

        private readonly List<DiveProfileData> _Profile = [];
        public ReadOnlyCollection<DiveProfileData> Profile => _Profile.AsReadOnly();

        public DiveData(double pSurfacePressure, double pExposureTime) {
            SurfacePressure = pSurfacePressure;
            Mixtures = [ new MixtureDTO(Enumeration.ModeEnum.Surfacegas,
                                        new MixtureGasDTO(GasEnum.O2, GasEnum.O2.StandardGasFraction),
                                        new MixtureGasDTO(GasEnum.N2, 100 - GasEnum.O2.StandardGasFraction - GasEnum.He.StandardGasFraction),
                                        new MixtureGasDTO(GasEnum.He, GasEnum.He.StandardGasFraction)) ];
            Calculator = CreateCalculatorInstance(GasEnum.Enumerate(true).Select(x => new GasDTO(x)).ToArray());
        }

        public void ProcessNewMeasurement(double pAmbientPressure, double pExposureTime, MixtureDTO pMixture) {
            _Profile.Add(new DiveProfileData(_Profile.Count + 1, DateTime.Now, pAmbientPressure, pExposureTime, pMixture));
            Current = Calculator.Calculate(pAmbientPressure, pExposureTime);

            if (Current.NDL < 0) {
                ICalculator tmpCalculator = CreateCalculatorInstance((GasDTO[])Calculator.GasComposition.Clone());
                List<Calculator.DTO.DecoStopDTO> decoStops = [];
                double currentPressure = pAmbientPressure;

                while (currentPressure % 0.3 != 0) {
                    currentPressure = currentPressure - 0.1;
                }
                Calculator.DTO.DiveProfileResult simulatedProfile = tmpCalculator.Calculate(currentPressure, pExposureTime);
                decoStops.Add(new Calculator.DTO.DecoStopDTO() {
                    Depth = simulatedProfile.MaxAscentHeight,
                    Time = simulatedProfile.TimeAtMaxAscentHeight
                });

                while (currentPressure > SurfacePressure) {
                    double stopDepth = Math.Max(SurfacePressure, currentPressure - 0.3);
                    double stopTime = 0;

                    simulatedProfile = tmpCalculator.Calculate(currentPressure, stopTime);

                    foreach (GasDTO.InertGasData gas in Enumerate()) {
                        for (int i = 0; i < gas.InertGas.Compartments.Length; i++) {
                            double ceiling = CalculateMaxAscentHeight(gas, i);
                            if (ceiling > stopDepth) {
                                stopTime = Math.Max(stopTime, CalculateTimeAtMaxAscentHeight(gas, i, stopDepth + SurfacePressure));
                            }
                        }
                    }

                    if (stopTime > 0) {
                        decoStops.Add(new DTO.DecoStopDTO() { Depth = stopDepth, Time = stopTime });
                    }

                    currentPressure = stopDepth;
                }

                return decoStops;
            }
        }

        public List<DTO.DecoStopDTO> CalculateAllDecompressionStops(double pAmbientPressure, double pExposureTime) {
            List<DTO.DecoStopDTO> decoStops = [];

            Calculate(pAmbientPressure, pExposureTime);

            double currentDepth = pAmbientPressure;
            while (currentDepth > SurfacePressure) {
                double stopDepth = Math.Max(SurfacePressure, Math.Floor(currentDepth - 3.0));
                double stopTime = 0;

                Calculate(currentDepth, stopTime);

                foreach (GasDTO.InertGasData gas in Enumerate()) {
                    for (int i = 0; i < gas.InertGas.Compartments.Length; i++) {
                        double ceiling = CalculateMaxAscentHeight(gas, i);
                        if (ceiling > stopDepth) {
                            stopTime = Math.Max(stopTime, CalculateTimeAtMaxAscentHeight(gas, i, stopDepth + SurfacePressure));
                        }
                    }
                }

                if (stopTime > 0) {
                    decoStops.Add(new DTO.DecoStopDTO() { Depth = stopDepth, Time = stopTime });
                }

                currentDepth = stopDepth;
            }

            return decoStops;
        }


        /// <summary>Fügt ein weiteres Atemgas der Auflistung hinzu.</summary>
        /// <param name="pGas"></param>
        public void AddMixture(MixtureDTO pGas) {
            if (!Mixtures.Contains(pGas)) {
                Mixtures.Add(pGas);
            }
        }

        private ICalculator CreateCalculatorInstance(GasDTO[] pGasComposition) {
            return new Calculator.Bühlmann.Calculator(this, pGasComposition);
        }
    }
}