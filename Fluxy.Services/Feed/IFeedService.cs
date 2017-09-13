using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fluxy.Services.Feed
{
    public interface IFeedService
    {
        /// <summary>
        /// Gets the feed containing meta data about the feed and the feed entries.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> signifying if the request is cancelled.</param>
        /// <returns>A <see cref="SyndicationFeed"/>.</returns>
        Task<SyndicationFeed> GetFeed(CancellationToken cancellationToken);

        /// <summary>
        /// Publishes the fact that the feed has updated to subscribers using the PubSubHubbub v0.4 protocol.
        /// </summary>
        /// <remarks>
        /// The PubSubHubbub is an open standard created by Google which allows subscription of feeds and allows 
        /// updates to be pushed to them rather than them having to poll the feed. This means subscribers get live
        /// updates as they happen and also we may save some bandwidth because we have less polling of our feed.
        /// See https://pubsubhubbub.googlecode.com/git/pubsubhubbub-core-0.4.html for PubSubHubbub v0.4 specification.
        /// See https://github.com/pubsubhubbub for PubSubHubbub GitHub projects.
        /// See http://pubsubhubbub.appspot.com/ for Google's implementation of the PubSubHubbub hub we are using.
        /// </remarks>
        Task PublishUpdate();
    }
}
