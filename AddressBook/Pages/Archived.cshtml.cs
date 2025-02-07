using AddressBook.Entities.Person;
using AddressBook.Entities.Person.Queries;
using AddressBook.Infrastructure.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AddressBook.Pages
{
    public class ArchivedModel : PageModel
    {
        public IEnumerable<Person> Persons { get; set; }
        public async Task OnGet([FromServices] QueryHandler<GetArchivedPersonQuery, IEnumerable<Person>> query)
        {
            Persons = await query(new GetArchivedPersonQuery());
        }

        public async Task<IActionResult> OnPost([FromServices] Person person)
        {
            await command(new GetArchivedPersonQuery());
            return RedirectToPage();
        }

        public Task command(GetArchivedPersonQuery getArchivedPersonQuery)
        {
            throw new NotImplementedException();
        }
    }
}
