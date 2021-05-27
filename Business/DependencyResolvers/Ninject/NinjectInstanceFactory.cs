using Ninject;

namespace Business.DependencyResolvers.Ninject
{
    public class NinjectInstanceFactory
    {
        public static T GetInstance<T>()
        {
            IKernel kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }
    }
}
