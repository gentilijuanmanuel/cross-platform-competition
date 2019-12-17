import './urls.model.dart';

class Photo {
  final String id;
  final String createdAt;
  final String updatedAt;
  final int width;
  final int height;
  final String color;
  final int downloads;
  final int likes;
  final String description;
  final Urls urls;
  final String username;
  final bool isFavorite;

  Photo({
    this.id,
    this.createdAt,
    this.updatedAt,
    this.width,
    this.height,
    this.color,
    this.downloads,
    this.likes,
    this.description,
    this.urls,
    this.username,
    this.isFavorite = false,
  });

  factory Photo.fromJson(Map<String, dynamic> json) {
    return Photo(
      id: json['id'],
      createdAt: json['created_at'],
      updatedAt: json['updated_at'],
      width: json['width'],
      height: json['height'],
      color: json['color'],
      downloads: json['downloads'],
      likes: json['likes'],
      urls: json['urls'] != null ? Urls.fromJson(json['urls']) : null,
      username: json['user'] != null ? json['user']['name'] : 'Anonymus',
      isFavorite: false,
    );
  }

  factory Photo.fromDb(Map<String, dynamic> dbRow) {
    return Photo(
      id: dbRow['id'],
      likes: dbRow['likes'],
      description: dbRow['description'],
      urls: Urls(regular: dbRow['url']),
      username: dbRow['username'],
      isFavorite: true,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'username': username,
      'likes': likes,
      'url': urls.regular,
      'description': description
    };
  }
}
