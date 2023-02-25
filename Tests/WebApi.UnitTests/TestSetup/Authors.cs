using System;
using WebApi_Param_Odev.DBOperations;
using WebApi_Param_Odev.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDBContext context)
        {
            context.Authors.AddRange
            (
                new Author{Name="Fyodor",Surname="Dostoyevski", DateOfBirth=new DateTime(1705,06,12)},
                new Author{Name="Karl",Surname="Marx", DateOfBirth=new DateTime(1996,06,12)},
                new Author{Name="Friedrich",Surname="Nietzsche", DateOfBirth=new DateTime(1844,06,12)}
            );
        }
    }
}