import 'dart:convert';

import 'package:cross_platform_competition/models/photo.model.dart';
import 'package:flutter/foundation.dart';
import 'package:http/http.dart' as http;

class PhotosRepository {
  static const _apiKey =
      "fa1ce8073b3d4b2244461ad657354b31658fb91de7820f5a5b15ba1fdf53d3e7";
  static const baseUrl = "https://api.unsplash.com/";
  final http.Client httpClient;

  PhotosRepository({@required this.httpClient});

  Future<List<Photo>> get() async {
    final url = '${baseUrl}search/photos?query=star%20wars&client_id=$_apiKey';

    final response = await http.get(url);
    final photosDecoded = jsonDecode(response.body);

    final List<Photo> photos = (photosDecoded['results'] as List)
        .map((c) => Photo.fromJson(c))
        .toList();

    return photos;
  }
}
