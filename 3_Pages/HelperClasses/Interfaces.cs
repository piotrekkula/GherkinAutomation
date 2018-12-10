// ------------------------------------------------------------------------------
//
//   Interfaces Helper class 
// 
//   This class is needed to click on various buttons independently of page we 
//   are currently on. This helps a lot when form pages are different.
//
// ------------------------------------------------------------------------------

namespace Helper.Interfaces
{
    public interface IHasSearchButton
    {
        void ClickSearchButton();
    }
    public interface IHasSaveButton
    {
        void ClickSaveButton();
    }
    public interface IHasEditButton
    {
        void ClickEditButton();
    }
    public interface IHasCancelButton
    {
        void ClickCancelButton();
    }
    public interface IHasNextButton
    {
        void ClickNextButton();
    }
    public interface IHasSendForVerificationButton
    {
        void SendForVerification();
    }
    public interface IHasSmokeTest
    {
        void SmokeTest();
    }
}