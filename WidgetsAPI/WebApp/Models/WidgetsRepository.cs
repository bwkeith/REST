using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class WidgetsRepository
    {
        #region Static

        #endregion Static

        #region Fields

        #endregion Fields

        #region Constructor

        #endregion Constructor

        #region Properties

        public List<Widget> Widgets => WebApiApplication.Widgets;

        #endregion Properties

        #region Methods

        public void Delete(int id)
        {
            var widgetToRemove = GetById(id);
            if (widgetToRemove != null)
            {
                Widgets.Remove(widgetToRemove);
            }
        }

        public List<Widget> GetAll()
        {
            return Widgets;
        }

        public Widget GetById(int id)
        {
            return Widgets.FirstOrDefault(w => w.Id == id);
        }

        public int Insert(Widget widget)
        {
            widget.Id = Widgets.Max(w => w.Id) + 1;
            Widgets.Add(widget);

            return widget.Id;
        }

        public bool Update(Widget widget)
        {
            var widgetToUpdate = GetById(widget.Id);
            if (widgetToUpdate == null)
            {
                return false;
            }

            widgetToUpdate.Name = widget.Name;
            widgetToUpdate.PartNumber = widget.PartNumber;
            widgetToUpdate.Value = widget.Value;

            return true;
        }

        #endregion Methods
    }
}
