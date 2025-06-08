using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMAUI.Interfaces
{
    public interface IServicioDialogo
    {
        public Task<string> ShowActionsAsync(string title, string message, string destruction, params string[] buttons);
        public Task<bool> ShowAlertAsync(string title, string message, string accept, string cancel);
        public Task<bool> ShowConfirmationAsync(string title, string message);
    }
}
