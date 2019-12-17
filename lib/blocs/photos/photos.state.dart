import '../../models/photo.model.dart';
import 'package:meta/meta.dart';

@immutable
abstract class PhotosState {}

class PhotosLoaded extends PhotosState {
  final List<Photo> photos;

  PhotosLoaded({this.photos});
}

class PhotosLoading extends PhotosState {}

class PhotosUnloaded extends PhotosState {}
