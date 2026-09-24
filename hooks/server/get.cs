import { markdownHtmlFromGetContext } from '@relay/md';
import { queryWidth, optimizeRasterFromGetContext } from '@relay/image';

export default function run(ctx, next) {
  var html = markdownHtmlFromGetContext(ctx);
  /* optimizeRaster requires opts.width — a bare ctx call always returns null. */
  var maxW = queryWidth(ctx);
  var optimized = maxW !== null ? optimizeRasterFromGetContext(ctx, null, { width: maxW }) : null;
  return html !== null ? html : optimized !== null ? optimized : next();
}
