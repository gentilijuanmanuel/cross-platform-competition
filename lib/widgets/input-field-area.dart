import 'package:flutter/material.dart';

class InputFieldArea extends StatelessWidget {
  final String hint;
  final bool obscure;
  final TextEditingController controller;

  InputFieldArea({this.hint, this.obscure, this.controller});

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
        border: Border(
          bottom: BorderSide(width: 0.5, color: Colors.black38),
        ),
      ),
      child: TextFormField(
        controller: controller,
        obscureText: obscure,
        style: TextStyle(color: Colors.white38),
        decoration: InputDecoration(
            border: InputBorder.none,
            hintText: hint,
            hintStyle: TextStyle(color: Colors.white, fontSize: 15.0),
            contentPadding: EdgeInsets.only(
                top: 30.0, right: 30.0, bottom: 30.0, left: 5.0)),
      ),
    );
  }
}
