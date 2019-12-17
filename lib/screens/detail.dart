import 'package:cross_platform_competition/blocs/photo/photo.bloc.dart';
import 'package:cross_platform_competition/blocs/photo/photo.state.dart';
import 'package:cross_platform_competition/widgets/input-field-area.dart';
import 'package:cross_platform_competition/widgets/photo-tile.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import '../blocs/photo/photo.event.dart';

class DetailsScreen extends StatefulWidget {
  @override
  _DetailsScreenState createState() => _DetailsScreenState();
}

class _DetailsScreenState extends State<DetailsScreen> {
  final descriptionController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Photo Detail'),
      ),
      body: BlocBuilder<PhotoBloc, PhotoState>(
        builder: (BuildContext context, PhotoState state) {
          if (state is PhotoLoaded) {
            return SingleChildScrollView(
              child: Padding(
                padding: const EdgeInsets.all(15.0),
                child: Column(
                  children: <Widget>[
                    PhotoTile(state.photo),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: <Widget>[
                        Column(
                          children: <Widget>[
                            Text(
                              'by ${state.photo.username}',
                              style: TextStyle(fontSize: 16.0),
                            ),
                            Container(
                              height: 3.0,
                            ),
                            Row(
                              children: <Widget>[
                                Padding(
                                    padding: EdgeInsets.only(right: 3.0),
                                    child: Text('${state.photo.likes}')),
                                Icon(
                                  Icons.favorite,
                                  size: 16.0,
                                )
                              ],
                            ),
                          ],
                        ),
                        IconButton(
                          icon: Icon(state.photo.isFavorite
                              ? Icons.bookmark
                              : Icons.bookmark_border),
                          onPressed: () {
                            state.photo.isFavorite
                                ? BlocProvider.of<PhotoBloc>(context)
                                    .add(RemoveFavorite(state.photo.id))
                                : BlocProvider.of<PhotoBloc>(context).add(
                                    AddFavorite(
                                      photo: state.photo,
                                      description: descriptionController.text,
                                    ),
                                  );
                          },
                        )
                      ],
                    ),
                    state.photo.isFavorite
                        ? Text(state.photo.description)
                        : InputFieldArea(
                            hint: 'Description',
                            obscure: false,
                            controller: descriptionController,
                          )
                  ],
                ),
              ),
            );
          }

          return CircularProgressIndicator();
        },
      ),
    );
  }
}
