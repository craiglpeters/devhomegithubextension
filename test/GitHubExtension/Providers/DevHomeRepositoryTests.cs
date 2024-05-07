using GitHubExtension.Providers;
using Xunit;

namespace GitHubExtension.Tests.Providers
{
    public class DevHomeRepositoryTests
    {
        private readonly DevHomeRepository _devHomeRepository;

        public DevHomeRepositoryTests()
        {
            _devHomeRepository = new DevHomeRepository();
        }

        [Fact]
        public void CreateCodespace_ShouldAddCodespaceToList()
        {
            // Arrange
            var initialCount = _devHomeRepository.ListCodespaces().Count;

            // Act
            _devHomeRepository.CreateCodespace("test/repo", "devcontainer.json", "Standard_Linux", "West US");

            // Assert
            var updatedCount = _devHomeRepository.ListCodespaces().Count;
            Assert.Equal(initialCount + 1, updatedCount);
        }

        [Fact]
        public void ListCodespaces_ShouldReturnAllCodespaces()
        {
            // Arrange
            _devHomeRepository.CreateCodespace("test/repo1", "devcontainer.json", "Standard_Linux", "West US");
            _devHomeRepository.CreateCodespace("test/repo2", "devcontainer.json", "Standard_Linux", "East US");

            // Act
            var codespaces = _devHomeRepository.ListCodespaces();

            // Assert
            Assert.Equal(2, codespaces.Count());
        }

        [Fact]
        public void DeleteCodespace_ShouldRemoveCodespaceFromList()
        {
            // Arrange
            _devHomeRepository.CreateCodespace("test/repo", "devcontainer.json", "Standard_Linux", "West US");
            var codespaceToDelete = _devHomeRepository.ListCodespaces().First();

            // Act
            _devHomeRepository.DeleteCodespace(codespaceToDelete);

            // Assert
            Assert.Empty(_devHomeRepository.ListCodespaces());
        }
    }
}
