// See https://aka.ms/new-console-template for more information
using ReponsitoryExample.Model;
using ReponsitoryExample.Repository;


var db = new AppDBContext();

// Repository<Category> repositoryCategory = new Repository<Category>(db);

// await repositoryCategory.Created(new Category{
//     Name = "abc1",
// });

// await repositoryCategory.Created(new Category{
//     Name = "abc2",
// });

// await repositoryCategory.Created(new Category{
//     Name = "abc3",
// });

// await repositoryCategory.Created(new Category{
//     Name = "abc4",
// });

// Console.WriteLine("Created: 4 Categories");

Repository<Customer> repositoryCustomer = new Repository<Customer>(db);
// await repositoryCustomer.Created(new Customer{
//     FirstName = "a",
//     LastName = "b",
//     Address = "Hue"
// });
// await repositoryCustomer.Created(new Customer{
//     FirstName = "a",
//     LastName = "c",
//     Address = "Huee"
// });
// Console.WriteLine("Created: 2 Categories");

var lsCustomer = repositoryCustomer.GetFilter(e => e.FirstName == "a").ToList();
foreach(var customer in lsCustomer)
{
    Console.WriteLine(customer.FirstName + " " + customer.LastName);
}
