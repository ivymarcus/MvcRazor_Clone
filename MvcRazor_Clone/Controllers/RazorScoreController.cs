using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcRazor_Clone.Models;

namespace MvcRazor_Clone.Controllers
{
    public class RazorScoreController : Controller
    {
        //學生考試成績model資料(沒有總分!)
        protected List<Student> students = new List<Student>
        {
            new Student { Id =1, Name="Joe", Chinese=88, English=95, Math=71 },
            new Student { Id =12, Name="Mary", Chinese=92, English=82, Math=60 },
            new Student { Id =23, Name="Cathy", Chinese=98, English=91, Math=94 },
            new Student { Id =34, Name="John", Chinese=63, English=85, Math=55 },
            new Student { Id =45, Name="David", Chinese=59, English=77, Math=82 }
        };

        // GET: RazorScore
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Scores()
        {
            return View(students);
        }

        // 先計算出每位學生總分，再找出總分最高者。
        public ActionResult ScoresRazor()
        {
            // 找出總分最高者之 Id
            int topId = 0;
            int topScore = 0;

            foreach(var student in students)
            {
                // 計算總分
                student.Total = student.Chinese + student.English + student.Math;

                // 判斷總分最高者
                if(student.Total > topScore)
                {
                    topScore = student.Total;
                    topId = student.Id;
                }
            }

            // Convert.ToInt32 => 將指定的值轉換為 32 位元帶正負號的整數。
            // 將最高分學生 Id 儲存到 ViewBag，傳遞給 View 
            ViewBag.TopId = Convert.ToInt32(topId);

            return View(students);
        }

    }
}