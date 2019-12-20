interface IUnsplash {
  description: String,
  id: number,
  url: string,
};

export interface IListProps {
  images: Array<IUnsplash>,
  onPress: Function,
};

export default IUnsplash;