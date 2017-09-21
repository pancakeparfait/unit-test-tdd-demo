using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Service.Commands.Common;
using WebApplication1.Service.Commands.Person;
using WebApplication1.Service.InfoObjects.Person;
using WebApplication1.Service.Queries.Person;

namespace WebApplication1.Service.Resources.Person
{
    /// <summary>
    /// The person resource constrains you to business behavior that a person business object allows
    /// </summary>
    public class PersonResourceService : IPersonResourceService
    {
        #region [Dependencies]

        private readonly IAllPeopleDataQuery _allPeopleDataQuery;
        private readonly IAddPersonDataCommand _addPersonDataCommand;
        private readonly IRemovePersonDataCommand _removePersonDataCommand;
        private readonly ISaveChangesCommand _saveChangesCommand;

        #endregion [Dependencies]

        #region [Ctors]

        public PersonResourceService(
            IAllPeopleDataQuery allPeopleDataQuery,
            IAddPersonDataCommand addPersonDataCommand,
            IRemovePersonDataCommand removePersonDataCommand,
            ISaveChangesCommand saveChangesCommand)
        {
            _allPeopleDataQuery = allPeopleDataQuery;
            _addPersonDataCommand = addPersonDataCommand;
            _removePersonDataCommand = removePersonDataCommand;
            _saveChangesCommand = saveChangesCommand;
        }

        #endregion [Ctors]

        public IEnumerable<PersonListInfo> GetAll()
        {
            var people = _allPeopleDataQuery.Execute();
            return people.Select(x => new PersonListInfo { Id = x.Id, Surname = x.Surname, GivenName = x.GivenName });
        }

        public void AddPerson(AddPersonInfo model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            _addPersonDataCommand.Execute(model.GivenName, model.Surname);
            _saveChangesCommand.Execute();
        }

        public void RemovePerson(int id)
        {
            _removePersonDataCommand.Execute(id);
            _saveChangesCommand.Execute();
        }
    }
}