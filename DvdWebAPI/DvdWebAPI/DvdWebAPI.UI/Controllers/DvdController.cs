using DvdWebAPI.Data.Factories;
using DvdWebAPI.Models.Queries;
using DvdWebAPI.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DvdWebAPI.UI.Controllers
{
    public class DvdController : ApiController
    {
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            var repo = DvdRepoFactory.GetRepository();
            var model = repo.GetAll();
            return Ok(model);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int dvdId)
        {
            DvdDetails dvd = DvdRepoFactory.GetRepository().GetByID(dvdId);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(AddDvdRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DvdDetails dvd = new DvdDetails()
            {
                Title = request.title,
                Year = request.realeaseYear,
                DirectorName = request.director,
                RatingValue = request.rating.ToUpper(),
                Note = request.notes
            };

            DvdRepoFactory.GetRepository().Insert(dvd);
            return Created($"dvd/{dvd.DvdID}", dvd);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Update(UpdateDvdRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var repo = DvdRepoFactory.GetRepository();

            DvdDetails dvd = repo.GetByID(request.dvdId);

            if (dvd == null)
            {
                return NotFound();
            }

            dvd.Title = request.title;
            dvd.Year = request.realeaseYear;
            dvd.DirectorName = request.director;
            dvd.RatingValue = request.rating.ToUpper();
            dvd.Note = request.notes;

            repo.Update(dvd);
            return Ok(dvd);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int dvdId)
        {
            DvdDetails dvd = DvdRepoFactory.GetRepository().GetByID(dvdId);

            if (dvd == null)
            {
                return NotFound();
            }

            DvdRepoFactory.GetRepository().Delete(dvdId);
            return Ok();
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchTitle(string title)
        {
            List<DvdDetails> dvds = DvdRepoFactory.GetRepository().GetByTitle(title);

            if (dvds == null)
            {
                return NotFound();
            }

            return Ok(dvds);
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchYear(int releaseYear)
        {
            List<DvdDetails> dvds = DvdRepoFactory.GetRepository().GetByYear(releaseYear);

            if (dvds == null)
            {
                return NotFound();
            }

            return Ok(dvds);
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchDirector(string directorName)
        {
            List<DvdDetails> dvds = DvdRepoFactory.GetRepository().GetByDirector(directorName);

            if (dvds == null)
            {
                return NotFound();
            }

            return Ok(dvds);
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchRating(string rating)
        {
            List<DvdDetails> dvds = DvdRepoFactory.GetRepository().GetByRating(rating);

            if (dvds == null)
            {
                return NotFound();
            }

            return Ok(dvds);
        }

        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}