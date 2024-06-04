using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETCalc {
    internal class DiveSegmentDTO {
        /// <summary>Druck in bar</summary>
        public double AmbientPressure { get; set; }

        /// <summary>Zeit in Minuten</summary>
        public double ExposureTime { get; set; }


        public double OxygenFraction { get; set; } // fraction of oxygen in the gas mix (e.g., 0.21 for air)
    }
}
