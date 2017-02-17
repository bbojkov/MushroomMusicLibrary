using System;
using WebFormsMvp;

namespace MusicLibrary.Web.PresenterFactories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}