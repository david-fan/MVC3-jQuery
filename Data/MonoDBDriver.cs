using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace AddressBook_mvc3_jQuery
{
	public class MonoDBDriver
	{
		public static Boolean added;
		public static void init()
		{
			if(added)
				return;

			var connectionString = "mongodb://127.0.0.1";
			var client = new MongoClient(connectionString);
			var server = client.GetServer();
			var database = server.GetDatabase("test");
			var collection = database.GetCollection<Entity>("entities");
			
			var entity = new Entity { Name = "Tom" };
			collection.Insert(entity);
			var id = entity.Id;
			
			var query = Query<Entity>.EQ(e => e.Id, id);
			entity = collection.FindOne(query);
			
			entity.Name = "Dick";
			collection.Save(entity);
			
			var update = Update<Entity>.Set(e => e.Name, "Harry");
			collection.Update(query, update);
			
			//collection.Remove(query);
			added=true;
	}

	public class Entity
	{
		public ObjectId Id { get; set; }
		public string Name { get; set; }
	}

}
}

