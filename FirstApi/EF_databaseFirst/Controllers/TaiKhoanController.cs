using EF_databaseFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EF_databaseFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ProjectContext projectContext;
        public TaiKhoanController(ProjectContext project)
        {
            this.projectContext = project;
        }

        // GET: api/<TaiKhoanController>
        [HttpGet]
        [Route("GetAll")]
        public List<TaiKhoan> GetAllTaiKhoan()
        {
            return projectContext.TaiKhoans.ToList();
            
        }

        // GET api/<TaiKhoanController>/5
        [HttpGet("{id}")]
       
        public string GetTaiKhoan(string id)
        {
            var tk = projectContext.TaiKhoans.FirstOrDefault(t => t.MaTaiKhoan == id);
            if (tk == null)
            {
                return "ko tim thay";
            }
            return tk.Sdt+"\n"+tk.MatKhau;
        }

        // POST api/<TaiKhoanController>
        [HttpPost]
        [Route("AddTk")]
        public string AddTaiKhoan(TaiKhoan tk) 
        {
            projectContext.TaiKhoans.Add(tk);
            projectContext.SaveChanges();
            return "added tk";

        }

        // PUT api/<TaiKhoanController>/5
        [HttpPut("/Update/{id}")]
        public string Update(string id,TaiKhoan tk)
        {
            var t=projectContext.TaiKhoans.FirstOrDefault(t=>t.MaTaiKhoan==id);
            if (t != null)
            {
                t.TenKhachHang = tk.TenKhachHang;
                t.MatKhau = tk.MatKhau+new string(' ', (20 - tk.MatKhau.Length));
                t.Sdt = tk.Sdt+ new string(' ', (20 - tk.Sdt.Length));
                t.Email = tk.Email + new string(' ', (100 - tk.Email.Length));
                
            }
            projectContext.SaveChanges() ;
            return "updated";
        }
        // DELETE api/<TaiKhoanController>/5
        [HttpDelete("DeleteTk/{id}")]
        
        public string Delete(string id)
        {
            var tk = projectContext.TaiKhoans.FirstOrDefault(t => t.MaTaiKhoan == id);
            if (tk != null)
            {
                var hd= projectContext.HoaDons.Where(t => t.MaTaiKhoan==id).ToList();
                foreach(var h in hd)
                {
                    var ve=projectContext.Ves.Where(v=>v.MaHoaDon==h.MaHoaDon).ToList();
                    foreach(var v in ve)
                    {
                        projectContext.Ves.Remove(v);
                    }
                    projectContext.HoaDons.Remove(h);
                }

                projectContext.TaiKhoans.Remove(tk);
                

                /*   var hd= projectContext.HoaDons.Where(h=> h.MaTaiKhoan == id).ToList();
                   foreach(var h in hd)
                   {
                       var ve= projectContext.Ves.FirstOrDefault(v => v.MaHoaDon == h.MaHoaDon);
                       projectContext.Ves.Remove(ve);
                       projectContext.HoaDons.Remove(h);

                   }*/

            }
            projectContext.SaveChanges();
            return "deleted";

        }
    }
}
