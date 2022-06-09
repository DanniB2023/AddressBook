using AddressBook.Infrastructure.Data;
using AddressBook.Infrastructure.Messages;

namespace AddressBook.Entities.Person.Queries
{
    public class QueryHandlers : IQueryHandler<GetAllPersonQuery, IEnumerable<Person>>, IQueryHandler<GetPersonByIdQuery, Person?>,
        IQueryHandler<GetActivePersonsQuery, IEnumerable<Person>>, IQueryHandler<GetArchivedPersonQuery, IEnumerable<Person>>
    {
        private readonly IPersonService database;

        public QueryHandlers(IPersonService person)
        {
            this.database = person;
        }

        public Task<IEnumerable<Person>> Handle(GetAllPersonQuery query, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(database.GetAllPersons());
        }

        public Task<Person?> Handle(GetPersonByIdQuery query, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(database.GetPersonById(query.Id));
        }

        public Task<IEnumerable<Person>> Handle(GetActivePersonsQuery query, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(database.GetAllPersons().Where(p => !p.Archived));
        }
        // Instead of returning all the results from the GetAllPersons, you'll implement a filter using a Where
        // method all on the results based on the Archived property.

        public Task<IEnumerable<Person>> Handle(GetArchivedPersonQuery query, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(database.GetAllPersons().Where(p => p.Archived));
        }
    }
}
