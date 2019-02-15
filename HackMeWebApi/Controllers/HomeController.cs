using HackMeWebApi.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;

namespace HackMeWebApi.Controllers
{
    public class HomeController : ApiController
    {
        DbHelper dbHelper = new DbHelper();

        List<StudentModel> listStudent = new List<StudentModel>()
        {
         new StudentModel { StudentId = 1, StudentName = "Yash Fale", StudentAddress = "Vapi"  },
         new StudentModel { StudentId = 2, StudentName = "Pankaj", StudentAddress = "town"  },
         new StudentModel { StudentId = 3, StudentName = "Om", StudentAddress = "chala"  }
        };

        [HttpGet]
        public IEnumerable<StudentModel> GetStudent()
        {
            return listStudent;
        }

        [HttpGet]
        public StudentModel GetStudent1(int id)
        {
            StudentModel studentDetailList = listStudent.FirstOrDefault(x => x.StudentId == id);

            return studentDetailList;
        }

        [HttpPut]
        public int UpdateStudent([FromBody] StudentModel studentModel)
        {
            string studentUpdate = @"
                UPDATE Tbl_Student SET StudentName = @StudentName,  StudentAddress = @StudentAddress WHERE StudentId = @StudentId";

            object[] param = new object[]
            {
                 new SqlParameter("@StudentName", studentModel.StudentName),
                 new SqlParameter("@StudentAddress", studentModel.StudentAddress),
                 new SqlParameter("@StudentId", studentModel.StudentId)
            };

           int response = dbHelper.ExecuteSqlCommand(studentUpdate, param);

            return response;
        }

        [HttpPost]
        public int AddStudent([FromBody] StudentModel studentModel)
        {
            string studentUpdate = @"
                INSERT INTO Tbl_Student VALUES(@StudentId,@StudentName,@StudentAddress)";

            object[] param = new object[]
            {
                 new SqlParameter("@StudentName", studentModel.StudentName),
                 new SqlParameter("@StudentAddress", studentModel.StudentAddress),
                 new SqlParameter("@StudentId", studentModel.StudentId)
            };

            int resonse =  dbHelper.ExecuteSqlCommand(studentUpdate, param);

            return resonse;
        }

        [HttpDelete]
        public int DeleteStudent(int id)
        {
            string delteStudent = @"
                DELETE Tbl_Student WHERE StudentId = @StudentId";

            object[] param = new object[]
            {
                 new SqlParameter("@StudentId", id)
            };

           int response =  dbHelper.ExecuteSqlCommand(delteStudent, param);

            return response;
        }
    }
}
