import '../../models/photo.model.dart';
import 'package:meta/meta.dart';

@immutable
abstract class PhotoState {}

class PhotoUnloaded extends PhotoState {}

class PhotoLoaded extends PhotoState {
  final Photo photo;

  PhotoLoaded(this.photo);
}
