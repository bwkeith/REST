using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsAPI.Models
{
    public static class WidgetsRepository
    {
        #region Static

        static WidgetsRepository()
        {
            Widgets.Add(new Widget { Id = 1, Name = "WidgetOne", Description = "This is the first widget." });
            Widgets.Add(new Widget { Id = 2, Name = "WidgetTwo", Description = "This is the second widget." });
            Widgets.Add(new Widget { Id = 3, Name = "WidgetThree", Description = "This is the third widget." });
            Widgets.Add(new Widget { Id = 4, Name = "WidgetFour", Description = "This is the fourth widget." });
            Widgets.Add(new Widget { Id = 5, Name = "WidgetFive", Description = "This is the fifth widget." });
        }

        #endregion Static

        #region Properties

        #region Widgets

        private static List<Widget> _widgets;

        public static List<Widget> Widgets
        {
            get { return _widgets ?? (_widgets = new List<Widget>()); }
        }

        #endregion Widgets

        #endregion Properties

        #region Methods

        public static void Delete(int id)
        {
            var widgetToRemove = Widgets.FirstOrDefault(w => w.Id == id);
            if (widgetToRemove != null)
            {
                Widgets.Remove(widgetToRemove);
            }
        }

        public static Widget Get(int id)
        {
            var widget = Widgets.FirstOrDefault(w => w.Id == id);

            return widget;
        }

        public static IEnumerable<Widget> GetAll()
        {
            return Widgets.ToList();
        }

        public static Widget Put(Widget widget)
        {
            if (widget.Id == 0)
            {
                // insert
                widget.Id = Widgets.Max(w => w.Id) + 1;
                Widgets.Add(widget);

                return widget;
            }

            // update
            var widgetToUpdate = Widgets.FirstOrDefault(w => w.Id == widget.Id);
            if (widgetToUpdate != null)
            {
                widgetToUpdate.Description = widget.Description;
                widgetToUpdate.Name = widget.Name;
            }
                
            return widgetToUpdate;
        }

        #endregion Methods
    }
}
