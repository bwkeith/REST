using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WidgetsAPI.Models;

namespace WidgetsAPI.Controllers
{
    public class WidgetsController : ApiController
    {
		// POST: api/Widgets
		public HttpResponseMessage Post([FromBody] Widget widget)
		{
			if (widget == null)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "widget is null");
			}

			try
			{
				var newWidget = WidgetsRepository.Put(widget);
				if (newWidget == null)
				{
					return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "unable to create widget");
				}

				return Request.CreateResponse(HttpStatusCode.OK, newWidget);
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
			}
		}
		
		// GET: api/Widgets
        public HttpResponseMessage Get()
        {
            try
            {
				var widgets = WidgetsRepository.GetAll();

				return Request.CreateResponse(HttpStatusCode.OK, widgets);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // GET: api/Widgets/5
        public HttpResponseMessage Get(int id)
        {
            if (id > 0)
            {
                try
                {
                    var widget = WidgetsRepository.Get(id);
                    if (widget == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "no widget found");
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, widget);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "id is invalid");
        }

        // PUT: api/Widgets/5
        public HttpResponseMessage Put([FromBody]Widget widget)
        {
            if (widget == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "widget is null");
            }

            try
            {
                var newWidget = WidgetsRepository.Put(widget);

                return Request.CreateResponse(HttpStatusCode.OK, newWidget);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // DELETE: api/Widgets/5
        public HttpResponseMessage Delete(int id)
        {
            if (id > 0)
            {
                try
                {
                    WidgetsRepository.Delete(id);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "id is invalid");
        }
    }
}
