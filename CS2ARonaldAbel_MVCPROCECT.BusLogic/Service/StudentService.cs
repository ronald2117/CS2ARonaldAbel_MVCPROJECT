﻿using CS2ARonaldAbel_MVCPROJECT.BusLogic.Model;
using CS2ARonaldAbel_MVCPROJECT.BusLogic.Respository;

namespace CS2ARonaldAbel_MVCPROJECT.BusLogic.Service
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository = new StudentRepository();
        
        public IEnumerable<tblStudent> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public bool Add(tblStudent student)
        {
            return _studentRepository.Add(student);
        }

        public tblStudent GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public bool Delete(int id)
        {
            return _studentRepository.Delete(id);
        }

        public bool Update(tblStudent student)
        {
            return _studentRepository.Update(student);
        }
    }
}
