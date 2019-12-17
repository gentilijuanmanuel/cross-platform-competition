import 'package:bloc/bloc.dart';
import './favorites.event.dart';
import './favorites.state.dart';
import '../../models/photo.model.dart';
import '../../repositories/favorites.repository.dart';

class FavoritesBloc extends Bloc<FavoritesEvent, FavoritesState> {
  final FavoritesRepository favoritesRepository;

  FavoritesBloc({this.favoritesRepository});

  @override
  FavoritesState get initialState => FavoritesUnloaded();

  @override
  Stream<FavoritesState> mapEventToState(
    FavoritesEvent event,
  ) async* {
    if (event is FetchFavorites) {
      yield FavoritesLoading();
      final List<Photo> photos = await this.favoritesRepository.getFavorites();

      yield FavoritesLoaded(photos: photos);
    }

    if (event is AddFavorite) {
      final oldPhotosState = (state as FavoritesLoaded).photos;
      yield FavoritesLoading();
      await this
          .favoritesRepository
          .addFavorite(event.photo, event.description);

      yield FavoritesLoaded(photos: [...oldPhotosState, event.photo]);
    }
  }
}
