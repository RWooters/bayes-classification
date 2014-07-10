using System.Collections.Generic;
using JetBrains.Annotations;

namespace BayesianClassifier
{
    /// <summary>
    /// Interface IDataSetAccessor
    /// </summary>
    public interface IDataSetAccessor : IEnumerable<TokenCount> 
    {
        /// <summary>
        /// Gets the number of distinct tokens, 
        /// i.e. every token counted at exactly once.
        /// </summary>
        /// <value>The token count.</value>
        /// <seealso cref="SetSize"/>
        long TokenCount { get; }

        /// <summary>
        /// Gets the size of the set.
        /// </summary>
        /// <value>The size of the set.</value>
        /// <seealso cref="TokenCount"/>
        long SetSize { get; }

        /// <summary>
        /// Gets the class.
        /// </summary>
        /// <value>The class.</value>
        [NotNull]
        IClass Class { get; }

        /// <summary>
        /// Gets the <see cref="TokenInformation{IToken}" /> with the specified token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>TokenInformation&lt;IToken&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">token</exception>
        TokenInformation<IToken> this[IToken token] { get; }

        /// <summary>
        /// Gets the number of occurrences of the given token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="System.ArgumentNullException">token</exception>
        /// <seealso cref="GetPercentage"/>
        long GetCount([NotNull] IToken token);

        /// <summary>
        /// Gets the approximated percentage of the given <see cref="IToken"/> in this data set
        /// by determining its occurrence count over the whole population.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>System.Double.</returns>
        /// <exception cref="System.ArgumentNullException">token</exception>
        /// <seealso cref="GetCount"/>
        double GetPercentage([NotNull] IToken token);
    }
}