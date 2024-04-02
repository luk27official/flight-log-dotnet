namespace FlightLogNet.Tests.Operation
{
    using Integration;
    using Models;
    using FlightLogNet.Operation;
    using FlightLogNet.Repositories.Interfaces;

    using Moq;

    using Xunit;

    public class CreatePersonOperationTests
    {
        private readonly MockRepository mockRepository;

        private readonly Mock<IPersonRepository> mockPersonRepository;
        private readonly Mock<IClubUserDatabase> mockClubUserDatabase;

        public CreatePersonOperationTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockPersonRepository = this.mockRepository.Create<IPersonRepository>();
            this.mockClubUserDatabase = this.mockRepository.Create<IClubUserDatabase>();
        }

        private CreatePersonOperation CreateCreatePersonOperation()
        {
            return new CreatePersonOperation(
                this.mockPersonRepository.Object,
                this.mockClubUserDatabase.Object);
        }

        [Fact]
        public void Execute_ShouldReturnNull()
        {
            // Arrange
            var createPersonOperation = this.CreateCreatePersonOperation();

            // Act
            var result = createPersonOperation.Execute(null);

            // Assert
            Assert.Null(result);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Execute_ShouldCreateGuest()
        {
            // Arrange
            var createPersonOperation = this.CreateCreatePersonOperation();
            PersonModel personModel = new PersonModel
            {
                Address = new AddressModel { City = "NY", PostalCode = "456", Street = "2nd Ev", Country = "USA" },
                FirstName = "John",
                LastName = "Smith"
            };
            this.mockPersonRepository.Setup(repository => repository.AddGuestPerson(personModel)).Returns(10);

            // Act
            var result = createPersonOperation.Execute(personModel);

            // Assert
            Assert.True(result > 0);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Execute_ShouldCreateNewClubMember()
        {
            // DONE 7.1: Naimplementujte test s pou�it�m mock�
            var createPersonOperation = CreateCreatePersonOperation();
            PersonModel personModel = new PersonModel
            {
                Address = new AddressModel { City = "NY", PostalCode = "456", Street = "2nd Ev", Country = "USA" },
                FirstName = "John",
                LastName = "Smith",
                MemberId = 1
            };

            long id;
            PersonModel returnedPersonModel = personModel;
            const long expectedId = 1;

            this.mockPersonRepository.Setup(repository => repository.TryGetPerson(personModel, out id)).Returns(false);

            this.mockClubUserDatabase.Setup(repository => repository.TryGetClubUser(expectedId, out returnedPersonModel)).Returns(true);

            this.mockPersonRepository.Setup(repository => repository.CreateClubMember(personModel)).Returns(expectedId);

            // Act
            var result = createPersonOperation.Execute(personModel);

            // Assert
            Assert.Equal(expectedId, result);
            this.mockRepository.VerifyAll();
        }
    }
}
