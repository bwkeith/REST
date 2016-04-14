using System;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class WidgetsController : ApiController
    {
        #region Static

        #endregion Static

        #region Fields

        private readonly WidgetsRepository _repository;

        #endregion Fields

        #region Constructor

        public WidgetsController()
        {
            _repository = new WidgetsRepository();
        }

        #endregion Constructor

        #region Properties

        #endregion Properties

        #region Methods

        #region Actions

        // GET api/widgets
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/widgets/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id < 1 || id > 9999)
                {
                    return BadRequest("id must be greater than 0 and less than 9999");
                }

                var widget = _repository.GetById(id);
                if (widget == null)
                {
                    return NotFound();
                }

                return Ok(widget);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/widgets
        public IHttpActionResult Post([FromBody]Widget widget)
        {
            try
            {
                if (widget == null)
                {
                    return BadRequest("json object is invalid");   
                }

                if (string.IsNullOrWhiteSpace(widget.Name) || string.IsNullOrWhiteSpace(widget.PartNumber) ||
                    widget.Value < 0)
                {
                    return BadRequest("a widget requires a name, part number, and a non-negative value");
                }

                var newId = _repository.Insert(widget);
                return newId > 0
                    ? (IHttpActionResult) Ok(newId)
                    : InternalServerError(new Exception("unable to insert widget"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/widgets/5
        public IHttpActionResult Put(int id, [FromBody]Widget widget)
        {
            try
            {
                if (widget == null)
                {
                    return BadRequest("json object is invalid");
                }

                if (string.IsNullOrWhiteSpace(widget.Name) || string.IsNullOrWhiteSpace(widget.PartNumber) ||
                    widget.Value < 0)
                {
                    return BadRequest("a widget requires a name, part number, and a non-negative value");
                }

                if (widget.Id > 0)
                {
                    // update
                    if (_repository.Update(widget))
                    {
                        return Ok();
                    }

                    return NotFound();
                }

                return BadRequest("must specify an id");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/widgets/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id < 1 || id > 9999)
                {
                    return BadRequest("id must be greater than 0 and less than 9999");
                }

                _repository.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion Actions

        #endregion Methods
    }
}
