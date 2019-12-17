import '../../models/photo.model.dart';
import 'package:meta/meta.dart';

@immutable
abstract class FavoritesState {}

class FavoritesUnloaded extends FavoritesState {}

class FavoritesLoaded extends FavoritesState {
  final List<Photo> photos;

  FavoritesLoaded({this.photos});
}

class FavoritesLoading extends FavoritesState {}

class FavoritesEmpty extends FavoritesState {}
