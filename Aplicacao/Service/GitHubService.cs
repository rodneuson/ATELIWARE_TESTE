using Aplicacao.Models;
using Newtonsoft.Json;

namespace Aplicacao.Service
{
    public static class GitHubService
    {
        public static GitHubApi GetAll()
        {
            // Busca items na API do GitHub
            var url = "https://api.github.com/search/repositories?q=language:&sort=stars&order=desc&page=1&per_page=10";
            var gitHubItems = JsonConvert.DeserializeObject<GitHubApi>(Util.WebRequest(url));

            // Salva dados no banco de dados
            using (var context = new BaseContext())
            {
                foreach (var item in gitHubItems.items)
                {
                    UpdateData(item, context);
                }
            }

            return gitHubItems;
        }

        public static GitHubApiItem GetItem(int id, string owner, string name)
        {
            var item = new GitHubApiItem();

            // Busca item no banco de dados
            using (var context = new BaseContext())
            {
                item = context.GitHubApiItems.Find(id);
                if(Equals(item, null))
                {
                    var url = string.Format("https://api.github.com/repos/{0}/{1}", owner, name);
                    item = JsonConvert.DeserializeObject<GitHubApiItem>(Util.WebRequest(url));

                    UpdateData(item, context);
                }
            }

            return item;
        }

        private static void UpdateData(GitHubApiItem item, BaseContext context)
        {
            var databaseItem = context.GitHubApiItems.Find(item.id);

            var update = true;
            if(Equals(databaseItem, null))
            {
                databaseItem = new GitHubApiItem { owner = new GitHubApiOwner() };
                update = false;
            }

            databaseItem.description = item.description;
            databaseItem.full_name = item.full_name;
            databaseItem.id = item.id;
            databaseItem.name = item.name;
            databaseItem.stargazers_count = item.stargazers_count;
            databaseItem.clone_url = item.clone_url;
            databaseItem.homepage = item.homepage;

            databaseItem.owner_id = item.owner.id;
            databaseItem.owner = item.owner;            

            if (update)
            {
                context.Entry(databaseItem).State = System.Data.Entity.EntityState.Modified;
                context.Entry(databaseItem.owner).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                context.GitHubApiItems.Add(databaseItem);
            }
            context.SaveChanges();
        }
    }
}