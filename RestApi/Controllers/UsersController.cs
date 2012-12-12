namespace RestApi.Controllers
{
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApi.DAL;
    using System.Data;
    using System.Data.Entity.Infrastructure;

    public class UserController : ApiController
    {
        private SongContext db = new SongContext();

        // GET api/Song
        public IEnumerable<User> GetSongs()
        {
            return db.Users.AsEnumerable();
        }

        // GET api/Song/5
        public User GetSong(int id)
        {
            User song = db.Users.Find(id);
            if (song == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return song;
        }

        // PUT api/Song/5
        public HttpResponseMessage PutSong(int id, User song)
        {
            if (ModelState.IsValid && id == song.ID)
            {
                db.Entry(song).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, song);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Song
        public HttpResponseMessage PostSong(User song)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(song);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, song);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = song.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Song/5
        public HttpResponseMessage DeleteSong(int id)
        {
            User song = db.Users.Find(id);
            if (song == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Users.Remove(song);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, song);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
