import 'package:cross_platform_competition/screens/explore.dart';
import 'package:cross_platform_competition/screens/favorites.dart';
import 'package:flutter/material.dart';

class HomeScreen extends StatefulWidget {
  @override
  _HomeScreenState createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  int _index = 0;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        bottomNavigationBar: BottomNavigationBar(
          items: [
            BottomNavigationBarItem(
              icon: Icon(Icons.photo_camera),
              activeIcon: Icon(
                Icons.photo_camera,
                color: Colors.teal,
              ),
              title: Text('Photos'),
            ),
            BottomNavigationBarItem(
              icon: Icon(Icons.bookmark_border),
              activeIcon: Icon(
                Icons.bookmark,
                color: Colors.teal,
              ),
              title: Text('Favorites'),
            ),
          ],
          currentIndex: _index,
          onTap: (index) {
            setState(() {
              _index = index;
            });
          },
        ),
        body: _getBody());
  }

  Widget _getBody() {
    if (_index == 0) {
      return ExploreScreen();
    }
    return FavoritesScreen();
  }
}
