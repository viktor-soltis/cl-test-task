using System;
using log4net;
using Task1.Enum;

namespace Task1
{
    /// <summary>
    /// Solves problem of determining is figure a triangle, 
    /// does it have correct sides sizes and if yes determining
    /// the actual type of triangle enumerated in 
    /// <see cref="TriangleTypeEnum"/> enum.
    /// </summary>
    public class TriangleTyper
    {
        private readonly ILog _log;

        public int SideA { get; set; }
        public int SideB { get; set; }
        public int SideC { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TriangleTyper"/> class.
        /// With taking expected triangle side sizes as arguments.
        /// </summary>
        /// <param name="sideA">The side A size.</param>
        /// <param name="sideB">The side B size.</param>
        /// <param name="sideC">The side C size.</param>
        public TriangleTyper(int sideA, int sideB, int sideC)
        {
            try
            {
                const string logFilePath = @"logTask1.log";

                var logManager = new Logger.LogManager(logFilePath, typeof(TriangleTyper).ToString());
                _log = logManager.Logger;

                _log.InfoFormat("Entered with arguments: sideA='{0}', sideB='{1}', sideC='{2}'",
                sideA, sideB, sideC);

                SideA = sideA;
                SideB = sideB;
                SideC = sideC;

                _log.InfoFormat("Setted properties: SideA='{0}', SideB='{1}', SideC='{2}'",
                SideA, SideB, SideC);
            }
            finally
            {
                _log.Info("Exited");
            }
        }

        /// <summary>
        /// The entry point for the <see cref="TriangleTyper"/> class,
        /// determines the type of figure, which sides were set during
        /// initialization of the <see cref="TriangleTyper"/> class,
        /// or during set of the properties SideA, SideB, SideC.
        /// </summary>
        /// <returns><see cref="TriangleTypeEnum"/></returns>
        public TriangleTypeEnum GetTriangleType()
        {
            _log.InfoFormat("Entered. Triangle sides: '{0}', '{1}', '{2}'",
                SideA, SideB, SideC);
            try
            {
                var triangleType = TriangleTypeEnum.NotTriangle;

                if (AreSidesValid() && IsTriangle())
                {
                    if (IsScalene())
                        triangleType = TriangleTypeEnum.Scalene;

                    if (IsIsosceles())
                        triangleType = TriangleTypeEnum.Isosceles;

                    if (IsEquilateral())
                        triangleType = TriangleTypeEnum.Equilateral;
                }

                _log.InfoFormat("Triangle type: '{0}'", triangleType);

                return triangleType;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                _log.Error(ex.ToString());
                return TriangleTypeEnum.NotTriangle;
            }
            finally
            {
                _log.Info("Exited");
            }
            
        }

        /// <summary>
        /// Checks if the sides setted in properties 
        /// SideA, SideB, SideC are valid.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool AreSidesValid()
        {
            _log.InfoFormat("Entered. Triangle sides: '{0}', '{1}', '{2}'",
                SideA, SideB, SideC);
            try
            {
                bool areSidesValid = SideA > 0 && SideB > 0 && SideC > 0;

                _log.InfoFormat("Are sides valid: '{0}'", areSidesValid);

                return areSidesValid;
            }
            finally
            {
                _log.Info("Exited");
            }
        }

        /// <summary>
        /// Determines whether figure setted with properties:
        /// SideA, SideB, SideC is a triangle.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool IsTriangle()
        {
            _log.InfoFormat("Entered. Triangle sides: '{0}', '{1}', '{2}'",
                SideA, SideB, SideC);
            try
            {
                var isValidTriangle = SideA + SideB > SideC
                        || SideA + SideC > SideB
                        || SideB + SideC > SideA;

                _log.InfoFormat("Is valid triangle: '{0}'", isValidTriangle);

                return AreSidesValid() && isValidTriangle;
            }
            finally
            {
                _log.Info("Exited");
            }
        }

        /// <summary>
        /// Determines whether figure setted with properties:
        /// SideA, SideB, SideC is a scalene triangle.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool IsScalene()
        {
            _log.InfoFormat("Entered. Triangle sides: '{0}', '{1}', '{2}'",
                SideA, SideB, SideC);
            try
            {
                bool isScalene = SideA != SideB && SideB != SideC && SideC != SideA;

                _log.InfoFormat("Is scalene: '{0}'", isScalene);

                return isScalene;
            }
            finally
            {
                _log.Info("Exited");
            }
            
        }

        /// <summary>
        /// Determines whether figure setted with properties:
        /// SideA, SideB, SideC is a isosceles triangle.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool IsIsosceles()
        {
            _log.InfoFormat("Entered. Triangle sides: '{0}', '{1}', '{2}'",
                SideA, SideB, SideC);
            try
            {
                bool isIsosceles = SideA == SideB || SideB == SideC || SideA == SideC;

                _log.InfoFormat("Is isosceles: '{0}'", isIsosceles);

                return isIsosceles;
            }
            finally
            {
                _log.Info("Exited");
            }
        }

        /// <summary>
        /// Determines whether figure setted with properties:
        /// SideA, SideB, SideC is a equilateral triangle.
        /// </summary>
        /// <returns></returns>
        public bool IsEquilateral()
        {
            _log.InfoFormat("Entered. Triangle sides: '{0}', '{1}', '{2}'",
                SideA, SideB, SideC);
            try
            {
                bool isEquilateral = SideA == SideB && SideB == SideC;

                _log.InfoFormat("Is isosceles: '{0}'", isEquilateral);

                return isEquilateral;
            }
            finally
            {
                _log.Info("Exited");
            }
        }
    }
}
