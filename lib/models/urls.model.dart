class Urls {
  final String raw;
  final String full;
  final String regular;
  final String small;
  final String thumb;

  Urls({this.raw, this.full, this.regular, this.small, this.thumb});

  factory Urls.fromJson(Map<String, dynamic> json) {
    return Urls(
        raw: json['raw'],
        full: json['full'],
        regular: json['regular'],
        small: json['small'],
        thumb: json['thumb']);
  }
}
