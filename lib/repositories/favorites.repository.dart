import 'package:cross_platform_competition/models/photo.model.dart';
import 'package:path/path.dart';
import 'package:sqflite/sqflite.dart';

class FavoritesRepository {
  FavoritesRepository();

  final database = () async =>
      openDatabase(join(await getDatabasesPath(), 'favorites_photos.db'),
          onCreate: (db, version) {
        return db.execute(
          "CREATE TABLE favorites(id TEXT PRIMARY KEY, likes INTEGER, url TEXT, username TEXT, description TEXT)",
        );
      }, version: 1);

  addFavorite(Photo photo, String description) async {
    final db = await database();
    final mappedPhoto = photo.toMap();
    mappedPhoto['description'] = description;
    await db.insert('favorites', mappedPhoto,
        conflictAlgorithm: ConflictAlgorithm.replace);
  }

  Future<List<Photo>> getFavorites() async {
    final db = await database();
    final List<Map<String, dynamic>> maps = await db.query('favorites');

    final List<Photo> photos =
        maps.map((dbPhoto) => Photo.fromDb(dbPhoto)).toList();

    return photos;
  }

  removeFavorite(String id) async {
    final db = await database();
    await db.delete('favorites', where: 'id = ?', whereArgs: [id]);
  }
}
