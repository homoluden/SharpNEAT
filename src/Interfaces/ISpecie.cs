using System.Collections.Generic;
using SharpNeat.Core;

namespace SharpNEAT.Interfaces
{
    public interface ISpecie<TGenome>
        where TGenome : class, IGenome<TGenome>
    {

        #region Properties

        /// <summary>
        /// Gets the specie's ID. Specie IDs are unique within a population.
        /// </summary>
        uint Id { get; }

        /// <summary>
        /// Gets or sets the index of the specie in its containing list. This is a working variable
        /// that typically will be the same as the specie ID but is not guaranteed to be e.g. in a distributed NEAT 
        /// environment where specie IDs may become non-contiguous.
        /// </summary>
        int Idx { get; set; }

        /// <summary>
        /// Gets the list of all genomes in the specie.
        /// </summary>
        List<TGenome> GenomeList { get; }

        /// <summary>
        /// Gets or sets the centroid position for all genomes within the specie. Note that this may be out of 
        /// date, it is the responsibility of code external to this class to recalculate and set a new centroid
        /// if the set of genomes in the specie has changed and therefore the specieList centroid has also changed.
        /// </summary>
        CoordinateVector Centroid { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Calculates the total fitness of all genomes within the specie.
        /// Implemented as a method rather than a property as an indication that this method does significant
        /// work to calculate the value.
        /// </summary>
        double CalcTotalFitness();

        /// <summary>
        /// Calculates the mean fitness of genomes within the specie.
        /// Implemented as a method rather than a property as an indication that this method does significant
        /// work to calculate the value.        
        /// </summary>
        double CalcMeanFitness();

        /// <summary>
        /// Calculates the total complexity of all genomes within the specie.
        /// Implemented as a method rather than a property as an indication that this method does significant
        /// work to calculate the value.
        /// </summary>
        double CalcTotalComplexity();

        /// <summary>
        /// Calculates the mean complexity of genomes within the specie.
        /// Implemented as a method rather than a property as an indication that this method does significant
        /// work to calculate the value.        
        /// </summary>
        double CalcMeanComplexity();

        #endregion

    }
}
