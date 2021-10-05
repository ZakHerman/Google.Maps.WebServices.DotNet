using System;
using System.Collections.Generic;
using System.Linq;
using Google.Maps.WebServices.Common;
using Google.Maps.WebServices.Util;
using Xunit;

namespace Google.Maps.WebServices.Tests.Util
{
    public class PolylineEncodingTests
    {
        private readonly string _encodedPath;

        public PolylineEncodingTests()
        {
            _encodedPath = GetEncodedPath();
        }

        [Fact]
        public void Decode_WithEmptyString_ReturnsEmptyCollection()
        {
            // Arrange
            string encodedPath = string.Empty;

            // Act
            List<LatLng> path = PolylineEncoding.Decode(encodedPath);

            // Assert
            Assert.Empty(path);
        }

        [Fact]
        public void Decode_WithNull_ThrowsArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => PolylineEncoding.Decode(null));
        }

        [Fact]
        public void Decode_WithValidEncodedPath_ReturnsLatLngCollection()
        {
            // Arrange
            var firstPoint = new LatLng(-33.86746, 151.20709);
            var lastPoint = new LatLng(-37.81413, 144.96318);

            // Act
            List<LatLng> path = PolylineEncoding.Decode(_encodedPath);

            // Assert
            Assert.Equal(firstPoint, path.FirstOrDefault());
            Assert.Equal(lastPoint, path.LastOrDefault());
        }

        [Fact]
        public void Encode_WithEmptyPath_ReturnsEmptyString()
        {
            // Act
            string encodedPath = PolylineEncoding.Encode(new List<LatLng>());

            // Assert
            Assert.Equal(string.Empty, encodedPath);
        }

        [Fact]
        public void Encode_WithNull_ThrowsArgumentNullException()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => PolylineEncoding.Encode(null));
        }

        [Fact]
        public void Encode_WithValidDecodedPath_ReturnsEncodedPath()
        {
            // Act
            List<LatLng> path = PolylineEncoding.Decode(_encodedPath);
            string encodedPath = PolylineEncoding.Encode(path);

            // Assert
            Assert.Equal(_encodedPath, encodedPath);
        }

        private static string GetEncodedPath()
        {
            return "rvumEis{y[`NsfA~tAbF`bEj^h{@{KlfA~eA~`AbmEghAt~D|e@jlRpO~yH_\\v}LjbBh~FdvCxu@`nCplDbcBf_B|w"
                   + "BhIfhCnqEb~D~jCn_EngApdEtoBbfClf@t_CzcCpoEr_Gz_DxmAphDjjBxqCviEf}B|pEvsEzbE~qGfpExjBlqCx}"
                   + "BvmLb`FbrQdpEvkAbjDllD|uDldDj`Ef|AzcEx_Gtm@vuI~xArwD`dArlFnhEzmHjtC~eDluAfkC|eAdhGpJh}N_m"
                   + "ArrDlr@h|HzjDbsAvy@~~EdTxpJje@jlEltBboDjJdvKyZpzExrAxpHfg@pmJg[tgJuqBnlIarAh}DbN`hCeOf_Ib"
                   + "xA~uFt|A|xEt_ArmBcN|sB|h@b_DjOzbJ{RlxCcfAp~AahAbqG~Gr}AerA`dCwlCbaFo]twKt{@bsG|}A~fDlvBvz"
                   + "@tw@rpD_r@rqB{PvbHek@vsHlh@ptNtm@fkD[~xFeEbyKnjDdyDbbBtuA|~Br|Gx_AfxCt}CjnHv`Ew\\lnBdrBfq"
                   + "BraD|{BldBxpG|]jqC`mArcBv]rdAxgBzdEb{InaBzyC}AzaEaIvrCzcAzsCtfD~qGoPfeEh]h`BxiB`e@`kBxfAv"
                   + "^pyA`}BhkCdoCtrC~bCxhCbgEplKrk@tiAteBwAxbCwuAnnCc]b{FjrDdjGhhGzfCrlDruBzSrnGhvDhcFzw@n{@z"
                   + "xAf}Fd{IzaDnbDjoAjqJjfDlbIlzAraBxrB}K~`GpuD~`BjmDhkBp{@r_AxCrnAjrCx`AzrBj{B|r@~qBbdAjtDnv"
                   + "CtNzpHxeApyC|GlfM`fHtMvqLjuEtlDvoFbnCt|@xmAvqBkGreFm~@hlHw|AltC}NtkGvhBfaJ|~@riAxuC~gErwC"
                   + "ttCzjAdmGuF`iFv`AxsJftD|nDr_QtbMz_DheAf~Buy@rlC`i@d_CljC`gBr|H|nAf_Fh{G|mE~kAhgKviEpaQnu@"
                   + "zwAlrA`G~gFnvItz@j{Cng@j{D{]`tEftCdcIsPz{DddE~}PlnE|dJnzG`eG`mF|aJdqDvoAwWjzHv`H`wOtjGzeX"
                   + "hhBlxErfCf{BtsCjpEjtD|}Aja@xnAbdDt|ErMrdFh{CzgAnlCnr@`wEM~mE`bA`uD|MlwKxmBvuFlhB|sN`_@fvB"
                   + "p`CxhCt_@loDsS|eDlmChgFlqCbjCxk@vbGxmCjbMba@rpBaoClcCk_DhgEzYdzBl\\vsA_JfGztAbShkGtEhlDzh"
                   + "C~w@hnB{e@yF}`D`_Ayx@~vGqn@l}CafC";
        }
    }
}
