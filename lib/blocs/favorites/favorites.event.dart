import 'package:cross_platform_competition/models/photo.model.dart';
import 'package:meta/meta.dart';

@immutable
abstract class FavoritesEvent {}

class FetchFavorites extends FavoritesEvent {}

class AddFavorite extends FavoritesEvent {
  final Photo photo;
  final String description;

  AddFavorite({@required this.photo, this.description});
}

class RemoveFavorite extends FavoritesEvent {
  final String id;

  RemoveFavorite(this.id);
}
