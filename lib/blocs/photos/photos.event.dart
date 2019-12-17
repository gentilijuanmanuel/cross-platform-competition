import 'package:meta/meta.dart';

@immutable
abstract class PhotosEvent {}

class FetchPhotos extends PhotosEvent {}
