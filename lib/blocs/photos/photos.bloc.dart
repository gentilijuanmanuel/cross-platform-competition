import 'package:bloc/bloc.dart';
import 'package:cross_platform_competition/repositories/favorites.repository.dart';
import './photos.event.dart';
import './photos.state.dart';
import '../../models/photo.model.dart';
import '../../repositories/photos.repository.dart';

class PhotosBloc extends Bloc<PhotosEvent, PhotosState> {
  final PhotosRepository photosRepository;
  final FavoritesRepository favoritesRepository;

  List<Photo> _photosCached = [];

  PhotosBloc({this.photosRepository, this.favoritesRepository});

  @override
  PhotosState get initialState => PhotosUnloaded();

  @override
  Stream<PhotosState> mapEventToState(
    PhotosEvent event,
  ) async* {
    if (event is FetchPhotos) {
      yield PhotosLoading();
      final List<Photo> photosApi = await this.photosRepository.get();
      final List<Photo> favorites =
          await this.favoritesRepository.getFavorites();
      final List<String> favoritesIds = favorites.map((p) => p.id).toList();

      final photos = photosApi.map((ph) {
        final favIndex = favorites.indexWhere((fav) => fav.id == ph.id);

        if (favIndex != -1) {
          return Photo(
              color: ph.color,
              createdAt: ph.createdAt,
              description: favorites[favIndex].description,
              downloads: ph.downloads,
              height: ph.height,
              id: ph.id,
              isFavorite: true,
              likes: ph.likes,
              updatedAt: ph.updatedAt,
              urls: ph.urls,
              username: ph.username,
              width: ph.width);
        }
        return ph;
      }).toList();

      yield PhotosLoaded(photos: photos);
    }
  }
}
