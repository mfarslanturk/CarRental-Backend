using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Engine;

namespace Core.DataAccess.NHibernate
{
    public abstract class NHibernateHelper:IDisposable
    {
        public static ISessionFactory _sessionFactory;

        public virtual ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = InitializeFactory()); }

        }

        protected abstract ISessionFactory InitializeFactory();

        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();

        }
        
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
