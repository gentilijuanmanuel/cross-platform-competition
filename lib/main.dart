import 'package:cross_platform_competition/blocs/photo/photo.bloc.dart';
import 'package:cross_platform_competition/blocs/photos/photos.bloc.dart';
import 'package:cross_platform_competition/repositories/favorites.repository.dart';
import 'package:cross_platform_competition/screens/home.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:http/http.dart' as http;

import './repositories/photos.repository.dart';
import './screens/explore.dart';
import 'package:flutter/material.dart';

import 'blocs/favorites/favorites.bloc.dart';

void main() {
  final photosRepository = new PhotosRepository(httpClient: http.Client());
  final favoritesRepository = new FavoritesRepository();

  runApp(MyApp(
    photosRepository: photosRepository,
    favoritesRepository: favoritesRepository,
  ));
}

class MyApp extends StatelessWidget {
  final PhotosRepository photosRepository;
  final FavoritesRepository favoritesRepository;

  MyApp({@required this.photosRepository, @required this.favoritesRepository});

  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider<PhotosBloc>(
          create: (context) => PhotosBloc(
              photosRepository: photosRepository,
              favoritesRepository: favoritesRepository),
        ),
        BlocProvider<FavoritesBloc>(
          create: (context) =>
              FavoritesBloc(favoritesRepository: favoritesRepository),
        ),
        BlocProvider<PhotoBloc>(
          create: (context) =>
              PhotoBloc(favoritesRepository: favoritesRepository),
        ),
      ],
      child: MaterialApp(
          title: 'Flutter Demo',
          themeMode: ThemeMode.dark,
          darkTheme: ThemeData.dark(),
          theme: ThemeData(
            primarySwatch: Colors.blue,
          ),
          home: HomeScreen()),
    );
  }
}
