import 'package:cross_platform_competition/blocs/favorites/favorites.bloc.dart';
import 'package:cross_platform_competition/blocs/favorites/favorites.event.dart';
import 'package:cross_platform_competition/blocs/favorites/favorites.state.dart';
import 'package:cross_platform_competition/widgets/staggered-photos-grid.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class FavoritesScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    BlocProvider.of<FavoritesBloc>(context).add(FetchFavorites());

    return Scaffold(
      body: BlocBuilder<FavoritesBloc, FavoritesState>(
        builder: (context, state) {
          if (state is FavoritesLoaded) {
            return StaggeredPhotosGrid(
              photos: state.photos,
            );
          }

          return Center(child: CircularProgressIndicator());
        },
      ),
    );
  }
}
