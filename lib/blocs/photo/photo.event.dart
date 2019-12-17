import 'package:cross_platform_competition/blocs/photos/photos.event.dart';
import 'package:cross_platform_competition/models/photo.model.dart';
import 'package:meta/meta.dart';

@immutable
abstract class PhotoEvent {}

class FetchPhoto extends PhotoEvent {
  final Photo photo;
  FetchPhoto(this.photo);
}

class AddFavorite extends PhotoEvent {
  final Photo photo;
  final String description;

  AddFavorite({@required this.photo, this.description});
}

class RemoveFavorite extends PhotoEvent {
  final String id;

  RemoveFavorite(this.id);
}
