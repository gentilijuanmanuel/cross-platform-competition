import 'package:cross_platform_competition/blocs/favorites/favorites.bloc.dart';
import 'package:cross_platform_competition/blocs/photos/photos.event.dart';
import 'package:cross_platform_competition/screens/detail.dart';
import 'package:cross_platform_competition/widgets/photo-tile.dart';
import 'package:cross_platform_competition/widgets/staggered-photos-grid.dart';
import 'package:flutter_staggered_grid_view/flutter_staggered_grid_view.dart';

import '../blocs/photos/photos.bloc.dart';
import '../blocs/photos/photos.state.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class ExploreScreen extends StatelessWidget {
  const ExploreScreen({Key key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    BlocProvider.of<PhotosBloc>(context).add(FetchPhotos());
    return Scaffold(
      appBar: AppBar(
        title: Text('Explore'),
      ),
      body: BlocBuilder<PhotosBloc, PhotosState>(
        builder: (context, state) {
          if (state is PhotosLoaded) {
            return StaggeredPhotosGrid(photos: state.photos);
          }
          return Center(
            child: CircularProgressIndicator(),
          );
        },
      ),
    );
  }
}
