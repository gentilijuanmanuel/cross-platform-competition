import 'package:cross_platform_competition/blocs/photo/photo.bloc.dart';
import 'package:cross_platform_competition/blocs/photo/photo.event.dart';
import 'package:cross_platform_competition/models/photo.model.dart';
import 'package:cross_platform_competition/screens/detail.dart';
import 'package:cross_platform_competition/widgets/photo-tile.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_staggered_grid_view/flutter_staggered_grid_view.dart';

class StaggeredPhotosGrid extends StatelessWidget {
  final List<Photo> photos;

  const StaggeredPhotosGrid({this.photos});
  @override
  Widget build(BuildContext context) {
    return StaggeredGridView.countBuilder(
      crossAxisCount: 4,
      itemCount: photos.length,
      itemBuilder: (BuildContext context, int index) => GestureDetector(
          onTap: () {
            BlocProvider.of<PhotoBloc>(context).add(FetchPhoto(photos[index]));
            Navigator.of(context).push(MaterialPageRoute(
              builder: (context) => DetailsScreen(),
              fullscreenDialog: true,
            ));
          },
          child: PhotoTile(photos[index])),
      staggeredTileBuilder: (int index) =>
          StaggeredTile.count(2, index.isEven ? 2 : 1),
      mainAxisSpacing: 15.0,
      crossAxisSpacing: 15.0,
    );
  }
}
