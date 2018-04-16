using Autofac;
using Autofac.Core.Lifetime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Http.Dependencies;

namespace LooseLyCoupleApp.Autofac
{
    [SecurityCritical]
    public class AutofacWebApiDependencyResolver : IDependencyResolver
    {

        private bool _disposed;
        readonly ILifetimeScope _container;
        readonly IDependencyScope _rootDependencyScope;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacWebApiDependencyResolver"/> class.
        /// </summary>
        /// <param name="container">The container that nested lifetime scopes will be create from.</param>
        public AutofacWebApiDependencyResolver(ILifetimeScope container)
        {
            if (container == null) throw new ArgumentNullException("container");

            _container = container;
            _rootDependencyScope = new AutofacWebApiDependencyScope(container);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="AutofacWebApiDependencyResolver"/> class.
        /// </summary>
        [SecuritySafeCritical]
        ~AutofacWebApiDependencyResolver()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the root container provided to the dependency resolver.
        /// </summary>
        public ILifetimeScope Container
        {
            get { return _container; }
        }

        /// <summary>
        /// Try to get a service of the given type.
        /// </summary>
        /// <param name="serviceType">Type of service to request.</param>
        /// <returns>An instance of the service, or null if the service is not found.</returns>
        [SecurityCritical]
        public object GetService(Type serviceType)
        {
            return _rootDependencyScope.GetService(serviceType);
        }

        /// <summary>
        /// Try to get a list of services of the given type.
        /// </summary>
        /// <param name="serviceType">ControllerType of services to request.</param>
        /// <returns>An enumeration (possibly empty) of the service.</returns>
        [SecurityCritical]
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _rootDependencyScope.GetServices(serviceType);
        }

        /// <summary>
        /// Starts a resolution scope. Objects which are resolved in the given scope will belong to
        /// that scope, and when the scope is disposed, those objects are returned to the container.
        /// </summary>
        /// <returns>
        /// The dependency scope.
        /// </returns>
        [SecurityCritical]
        public IDependencyScope BeginScope()
        {
            var lifetimeScope = _container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            return new AutofacWebApiDependencyScope(lifetimeScope);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        [SecuritySafeCritical]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_rootDependencyScope != null)
                    {
                        _rootDependencyScope.Dispose();
                    }
                }
                _disposed = true;
            }
        }

    }
}