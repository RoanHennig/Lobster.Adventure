conn = new Mongo();
db = conn.getDB("lobster");


db.adventure.createIndex({ "userId": 1, "name": 1 }, { unique: true });
db.adventure_result.createIndex({ "userId": 1, "adventureName": 1, "adventureTakenDate": 1 }, { unique: true });