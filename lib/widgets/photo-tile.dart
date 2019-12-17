import 'package:cross_platform_competition/models/photo.model.dart';
import 'package:flutter/material.dart';

class PhotoTile extends StatelessWidget {
  final Photo photo;

  PhotoTile(this.photo);

  @override
  Widget build(BuildContext context) {
    return ClipRRect(
      borderRadius: BorderRadius.circular(20.0),
      child: Container(
        constraints:
            BoxConstraints(maxHeight: MediaQuery.of(context).size.height / 2),
        decoration: BoxDecoration(borderRadius: BorderRadius.circular(20.0)),
        child: Image.network(
          photo.urls.regular,
          fit: BoxFit.cover,
        ),
      ),
    );
  }
}
