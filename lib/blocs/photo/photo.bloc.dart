import 'package:bloc/bloc.dart';
import 'package:cross_platform_competition/blocs/photo/photo.event.dart';
import 'package:cross_platform_competition/blocs/photo/photo.state.dart';
import '../../models/photo.model.dart';
import '../../repositories/favorites.repository.dart';

class PhotoBloc extends Bloc<PhotoEvent, PhotoState> {
  final FavoritesRepository favoritesRepository;

  PhotoBloc({this.favoritesRepository});

  @override
  PhotoState get initialState => PhotoUnloaded();

  @override
  Stream<PhotoState> mapEventToState(
    PhotoEvent event,
  ) async* {
    if (event is FetchPhoto) {
      yield PhotoLoaded(event.photo);
    }

    if (event is AddFavorite) {
      final oldState = (state as PhotoLoaded).photo;
      final newPhoto = Photo(
          id: oldState.id,
          description: event.description,
          urls: oldState.urls,
          isFavorite: true,
          likes: oldState.likes,
          username: oldState.username);

      yield PhotoLoaded(newPhoto);

      try {
        await this
            .favoritesRepository
            .addFavorite(event.photo, event.description);
      } on Exception catch (e) {
        yield PhotoLoaded(oldState);
      }
    }

    if (event is RemoveFavorite) {
      final oldState = (state as PhotoLoaded).photo;
      final newPhoto = Photo(
          id: oldState.id,
          description: '',
          urls: oldState.urls,
          isFavorite: false,
          likes: oldState.likes,
          username: oldState.username);

      yield PhotoLoaded(newPhoto);

      try {
        await this.favoritesRepository.removeFavorite(event.id);
      } on Exception catch (e) {
        yield PhotoLoaded(oldState);
      }
    }
  }
}
