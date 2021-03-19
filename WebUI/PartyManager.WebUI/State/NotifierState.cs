using PartyManager.Application.Shared.Responding;
using System;

namespace PartyManager.WebUI.State
{
    public class NotifierState
    {
        public bool Display { get; set; } = false;
        public string Message { get; set; } = "Something Happened";
        public bool Success { get; set; } = true;

        public event Action OnChange;

        public void Notify(Response response)
        {
            Notify(response.Message, response.Success);
        }

        public void Notify(string message, bool success)
        {
            Message = message;
            Success = success;
            Display = true;
            StateChanged();
        }

        public void NotifyClose()
        {
            Display = false;
            Message = "";
            StateChanged();
        }

        private void StateChanged() => OnChange?.Invoke();
    }
}
